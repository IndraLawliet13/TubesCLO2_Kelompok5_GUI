using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TubesCLO2_Kelompok5_GUI.Models;
using TubesCLO2_Kelompok5_GUI.Services;

namespace TubesCLO2_Kelompok5_GUI.Controllers
{
    public class MainController
    {
        private readonly MahasiswaApiClient _apiClient;
        private readonly ConfigurationService _configService;

        public ConfigurationService ConfigService { get { return _configService; } }

        // Updated constructor to accept ConfigurationService
        public MainController(ConfigurationService configService)
        {
            _configService = configService; // Use the passed instance
            _apiClient = new MahasiswaApiClient(_configService);
        }

        public async Task<List<Mahasiswa>> GetAllMahasiswaAsync()
        {
            try
            {
                var response = await _apiClient.GetAllMahasiswaAsync();
                if (response != null && response.Status == 200)
                {
                    return response.Data;
                }
                return new List<Mahasiswa>();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it, show a message)
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return new List<Mahasiswa>();
            }
        }

        public async Task<bool> DeleteMahasiswaAsync(string nim)
        {
            try
            {
                var response = await _apiClient.DeleteMahasiswaAsync(nim);
                return response != null && response.Status == 200;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting data: {ex.Message}");
                return false;
            }
        }

        public async Task<ApiResponse<Mahasiswa>?> AddMahasiswaAsync(Mahasiswa mahasiswa)
        {
            try
            {
                // Assuming _apiClient.AddMahasiswaAsync already returns ApiResponse<Mahasiswa>
                return await _apiClient.AddMahasiswaAsync(mahasiswa);
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine($"Error in MainController.AddMahasiswaAsync: {ex.Message}");
                // Return a generic error response or rethrow, depending on desired error handling strategy
                return new ApiResponse<Mahasiswa>
                {
                    Message = $"An error occurred in Controller: {ex.Message}",
                    Data = null,
                };
            }
        }

        public async Task<ApiResponse<Mahasiswa>?> UpdateMahasiswaAsync(string nim, Mahasiswa mahasiswa)
        {
            try
            {
                // Assuming _apiClient.UpdateMahasiswaAsync already returns ApiResponse<Mahasiswa>
                return await _apiClient.UpdateMahasiswaAsync(nim, mahasiswa);
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine($"Error in MainController.UpdateMahasiswaAsync: {ex.Message}");
                return new ApiResponse<Mahasiswa>
                {
                    Message = $"An error occurred in Controller: {ex.Message}",
                    Data = null,
                };
            }
        }
    }
}