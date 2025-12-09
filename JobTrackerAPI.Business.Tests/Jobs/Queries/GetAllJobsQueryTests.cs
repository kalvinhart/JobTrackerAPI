using JobTrackerAPI.Business.Jobs.Queries.GetAllJobs;
using JobTrackerAPI.DataAccess.Common.UnitOfWork;
using JobTrackerAPI.DataAccess.Jobs.Entities;
using JobTrackerAPI.DataAccess.Jobs.Enums;
using Moq;

namespace JobTrackerAPI.Business.Tests.Jobs.Queries;

[TestFixture]
public class GetAllJobsQueryTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly GetAllJobsQueryHandler _handler;

    public GetAllJobsQueryTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetAllJobsQueryHandler(_unitOfWork.Object);
    }

    [SetUp]
    public void Setup()
    {
        _unitOfWork.Reset();
    }

    [Test]
    public async Task GetAllJobsQuery_ShouldReturnJobs()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var query = new GetAllJobsQuery();
        List<Job> jobs = [
            new Job
            {
                Id = Guid.NewGuid(),
                Title = "Test Job 1",
                Location = "Test Location 1",
                Description = "Test Description 1",
                SalaryStart = 1000,
                SalaryEnd = 2000,
                ContactName = "Test Contact 1",
                Status = ApplicationStatus.Pending,
                UserId = userId
            },
            new Job
            {
                Id = Guid.NewGuid(),
                Title = "Test Job 2",
                Location = "Test Location 2",
                Description = "Test Description 2",
                SalaryStart = 3000,
                SalaryEnd = 4000,
                ContactName = "Test Contact 2",
                Status = ApplicationStatus.Interviewing,
                UserId = userId
            }
        ];

        _unitOfWork
            .Setup(x => x.Jobs.GetAllAsync().Result)
            .Returns(jobs);

        // Act
        var result = await _handler.Handle(query, new CancellationToken());

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(
            () =>
            {
                Assert.That(result[0].Title, Is.EqualTo("Test Job 1"));
                Assert.That(result[0].Location, Is.EqualTo("Test Location 1"));
                Assert.That(result[0].Description, Is.EqualTo("Test Description 1"));
                Assert.That(result[0].SalaryStart, Is.EqualTo(1000));
                Assert.That(result[0].SalaryEnd, Is.EqualTo(2000));
                Assert.That(result[0].ContactName, Is.EqualTo("Test Contact 1"));
                Assert.That(result[0].Status, Is.EqualTo(ApplicationStatus.Pending));
                Assert.That(result[0].UserId, Is.EqualTo(userId));

                Assert.That(result[1].Title, Is.EqualTo("Test Job 2"));
                Assert.That(result[1].Location, Is.EqualTo("Test Location 2"));
                Assert.That(result[1].Description, Is.EqualTo("Test Description 2"));
                Assert.That(result[1].SalaryStart, Is.EqualTo(3000));
                Assert.That(result[1].SalaryEnd, Is.EqualTo(4000));
                Assert.That(result[1].ContactName, Is.EqualTo("Test Contact 2"));
                Assert.That(result[1].Status, Is.EqualTo(ApplicationStatus.Interviewing));
                Assert.That(result[1].UserId, Is.EqualTo(userId));
            });
    }
}