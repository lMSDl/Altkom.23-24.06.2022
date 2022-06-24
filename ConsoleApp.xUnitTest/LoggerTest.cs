using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.xUnitTest
{
    public class LoggerTest
    {

        public void Log_AnyString_MessageLogged()
        {
            //TODO
        }

        [Fact]
        public void Log_AnyString_EventInvoked()
        {
            //Arrage
            var logger = new Logger();
            var result = false;
            logger.MessageLogged += (sender, args) => result = true;

            //Act
            logger.Log("");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Log_AnyString_EventArgsFilled()
        {
            //Arrage
            var logger = new Logger();
            EventArgs? actualArgs = null;
            logger.MessageLogged += (sender, args) => actualArgs = args;
            var dateTimeNow = DateTime.Now;
            
            //Act
            logger.Log("A");

            //Assert
            //var loggerEventArgs = Assert.IsType<Logger.LoggerEventArgs>(actualArgs);
            //Assert.Equal("A", loggerEventArgs.Message);
            //Assert.True(DateTime.Now.AddMilliseconds(-100) < loggerEventArgs.DateTime);

            using (new AssertionScope())
            {
                var loggerEventArgs = actualArgs.Should().BeOfType<Logger.LoggerEventArgs>().Subject;
                loggerEventArgs.Message.Should().Be("A");
                loggerEventArgs.DateTime.Should().BeOnOrAfter(dateTimeNow);
            }
        }

        [Fact]
        public async Task GetLogsAsync_ReturnsLoggedMessages()
        {
            //Arrage
            var logger = new Logger();
            logger.Log("A");

            //Act
            var task = logger.GetLogsAsync(DateTime.Now.AddSeconds(-1), DateTime.Now);
            var result = await task;

            //Assert
            Assert.True(task.IsCompletedSuccessfully);
            Assert.Contains("A", result);
            Assert.True(DateTime.TryParseExact(result.Split(": ")[0], "dd.MM.yyyy hh:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _));
        }
    }
}
