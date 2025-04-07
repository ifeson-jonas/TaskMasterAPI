using Moq;
using TaskMasterAPI.Interfaces.Repositories;
using TaskMasterAPI.Models.Entities;
using TaskMasterAPI.Services;
using Xunit;

namespace TaskMasterAPI.Tests.Services;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepo;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _service = new TaskService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetTaskAsync_ReturnsTask_WhenExists()
    {
        // Arrange
        var testTask = new TaskItem { Id = 1, Title = "Test" };
        _mockRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(testTask);

        // Act
        var result = await _service.GetTaskAsync(1, 1);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(testTask, result.Data);
    }

    [Fact]
    public async Task GetTaskAsync_ReturnsNotFound_WhenNotExists()
    {
        // Arrange
        _mockRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync((TaskItem?)null);

        // Act
        var result = await _service.GetTaskAsync(1, 1);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(404, result.StatusCode);
    }
}

