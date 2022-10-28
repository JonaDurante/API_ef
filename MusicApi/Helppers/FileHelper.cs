using Azure.Storage.Blobs;

namespace MusicApi.Helppers
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = ""; // Acá va la URL de Azure o de la nuve donde almacene las imágenes
            string conteinerName = ""; // Acá va la URL del container o de la nuve donde almacene las imágenes

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, conteinerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream); // esta linea es la encargada de cargar la imagen a Azure
            return blobClient.Uri.AbsoluteUri; // Asigno La url obtenida a la imagen
        }

        public static async Task<string> UploadFile(IFormFile file)
        {
            string connectionString = ""; // Acá va la URL de Azure o de la nuve donde almacene las imágenes
            string conteinerName = ""; // Acá va la URL del container o de la nuve donde almacene las imágenes

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, conteinerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream); // esta linea es la encargada de cargar la imagen a Azure
            return blobClient.Uri.AbsoluteUri; // Asigno La url obtenida a la imagen
        }
    }
}
