﻿using Azure.Storage.Blobs;
using System.Text.RegularExpressions;

namespace Automobilis.Api.Services
{
    public class FileUpload
    {
        private readonly IConfiguration _configuration;

        public FileUpload(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string UploadBase64Image(string base64Image, string container)
        {
            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient(_configuration.GetSection("azureStorage").Value, container, fileName);

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
