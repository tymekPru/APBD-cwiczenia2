using System.Text.Json;
using System.Text.Json.Serialization;
using APBD_cwiczenia2.Repositories;
namespace APBD_cwiczenia2
{
    public class AppStateLoader
    {
        private readonly string _filePath;

        public AppStateLoader()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save");
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            _filePath = Path.Combine(directory, "data.json");
        }

        public void Save(DeviceRepository dr, UserRepository ur, RentalRepository rr)
        {
            var state = new AppState
            {
                Devices = dr.GetAll(),
                NextDeviceId = dr.GetNextId(),
                Users = ur.GetAll(),
                NextUserId = ur.GetNextId(),
                Rentals = rr.GetAll(),
                NextRentalId = rr.GetNextId()
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string json = JsonSerializer.Serialize(state, options);
            File.WriteAllText(_filePath, json);
        }

        public void Load(DeviceRepository dr, UserRepository ur, RentalRepository rr)
        {
            if (!File.Exists(_filePath)) return;

            string json = File.ReadAllText(_filePath);
            var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            var state = JsonSerializer.Deserialize<AppState>(json, options);

            if (state != null)
            {
                dr.Restore(state.Devices, state.NextDeviceId);
                ur.Restore(state.Users, state.NextUserId);
                rr.Restore(state.Rentals, state.NextRentalId);
            }
        }
    }
}