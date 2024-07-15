using JobTrackerAPI.Business.Jobs.Commands.CreateJob;
using JobTrackerAPI.Business.Jobs.DTOs;
using JobTrackerAPI.DataAccess.Common.UnitOfWork;
using JobTrackerAPI.DataAccess.Jobs.Entities;
using JobTrackerAPI.DataAccess.Jobs.Enums;
using Moq;

namespace JobTrackerAPI.Business.Tests.Jobs.Commands;

[TestFixture]
public class CreateJobCommandTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly CreateJobCommandHandler _handler;

    public CreateJobCommandTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateJobCommandHandler(_unitOfWork.Object);
    }

    [SetUp]
    public void Setup()
    {
        _unitOfWork.Reset();
    }

    [Test]
    public async Task CreateJobCommand_ShouldReturnJob_WhenSuccessful()
    {
        // Arrange
        CreateJobDto createJobDto = new(
            Title: "Test Job",
            Location: "Test Location",
            Description: "Test Description",
            SalaryStart: 1000,
            SalaryEnd: 2000,
            ContactName: "Test Contact");

        Guid userId = Guid.NewGuid();
        
        _unitOfWork
            .Setup(u => u.Jobs.Add(It.IsAny<Job>()));

        var command = new CreateJobCommand(createJobDto, userId);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        _unitOfWork.Verify(u => u.Jobs.Add(It.IsAny<Job>()), Times.Once);

        Assert.Multiple(
            () =>
            {
                Assert.That(result.Title, Is.EqualTo(createJobDto.Title));
                Assert.That(result.Location, Is.EqualTo(createJobDto.Location));
                Assert.That(result.Description, Is.EqualTo(createJobDto.Description));
                Assert.That(result.SalaryStart, Is.EqualTo(createJobDto.SalaryStart));
                Assert.That(result.SalaryEnd, Is.EqualTo(createJobDto.SalaryEnd));
                Assert.That(result.ContactName, Is.EqualTo(createJobDto.ContactName));
                Assert.That(result.Status, Is.EqualTo(ApplicationStatus.Pending));
                Assert.That(result.UserId, Is.EqualTo(userId));
            });
    }
}