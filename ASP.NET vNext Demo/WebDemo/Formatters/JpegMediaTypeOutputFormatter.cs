using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.HeaderValueAbstractions;
using WebDemo.Models;

namespace WebDemo.Formatters
{
    public class JpegMediaTypeOutputFormatter : OutputFormatter
    {
        private readonly string _folder;
        public JpegMediaTypeOutputFormatter(string folder)
        {
            _folder = folder;

            SupportedEncodings.Add(Encodings.UTF8EncodingWithoutBOM);
            SupportedEncodings.Add(Encodings.UTF16EncodingLittleEndian);

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("image/jpeg"));
        }

        public override bool CanWriteResult(OutputFormatterContext context, MediaTypeHeaderValue contentType)
        {
            return context.DeclaredType == typeof (Book) || context.Object is Book;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterContext context)
        {
            var response = context.ActionContext.HttpContext.Response;

            var book = context.Object as Book;
            if (book != null)
            {
                var path = Path.Combine(_folder, book.ImageName);
                var buffer = File.ReadAllBytes(path);

                response.Body.Write(buffer, 0, buffer.Length);
            }

            return Task.FromResult(true);
        }
    }
}