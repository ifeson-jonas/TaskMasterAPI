using Moq;
using Xunit;
using TaskMasterAPI.Models.Entities;
using TaskMasterAPI.Interfaces.Repositories;
using TaskMasterAPI.Services;
using System.Threading.Tasks;

namespace TaskMasterAPI.Tests.Services
{
    public class TaskServiceTests
    {
        private readonly TaskService _service;
        private readonly Mock<ITaskRepository> _mockRepo;

        public TaskServiceTests()
        {
            _mockRepo = new Mock<ITaskRepository>();
            _service = new TaskService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetTaskAsync_ReturnsTask_WhenExists()
        {
            // Arrange
            var task = new TaskItem { Id = 1, Title = "Test Task", UserId = 1 };
            _mockRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(task);

            // Act
            var result = await _service.GetTaskAsync(1, 1);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("Test Task", result.Data?.Title);
        }

        [Fact]
        public async Task GetTaskAsync_ReturnsNull_WhenNotExists()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync((TaskItem?)null);

            // Act
            var result = await _service.GetTaskAsync(1, 1);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
        }
    }
}
