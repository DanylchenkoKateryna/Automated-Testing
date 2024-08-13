using CalcClassBr;

using System;
using System.IO;

using Xunit;

namespace TestProject2.Tests
{
    public class FileDocumentUploaderTests : IDisposable
    {
        private readonly string _tempFilePath;

        public FileDocumentUploaderTests()
        {
            _tempFilePath = Path.GetTempFileName();
            File.WriteAllText(_tempFilePath, "Test content");
        }

        public void Dispose()
        {
            if (File.Exists(_tempFilePath))
            {
                File.Delete(_tempFilePath);
            }
        }

        [Fact]
        public void UploadDocument_ValidPath_ReturnsFileStream()
        {
            // Arrange
            var fileUploader = new FileDocumentUploader(_tempFilePath);

            // Act
            using (var result = fileUploader.UploadDocument())
            {
                // Assert
                Assert.NotNull(result);
                Assert.IsType<FileStream>(result);
                Assert.True(result.CanRead);

                using (var reader = new StreamReader(result))
                {
                    string content = reader.ReadToEnd();
                    Assert.Equal("Test content", content);
                }
            }
        }

        [Fact] 
        public void UploadDocument_InvalidPath_ThrowsFileNotFoundException()
        {
            // Arrange
            var invalidFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var fileUploader = new FileDocumentUploader(invalidFilePath);

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => fileUploader.UploadDocument());
        }
    }
}
