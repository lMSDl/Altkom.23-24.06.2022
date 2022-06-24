using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.xUnitTest
{
    public class ProgramTest
    {
        [Fact]
        public void MainTest()
        {
            //Arrage
            SwitchConsoleOutput(out var stringWriter, out var consoleOutput);
            var entryPoint = typeof(Program).Assembly.EntryPoint!;

            //Act
            entryPoint.Invoke(null, new object[] { Array.Empty<string>() });

            //Assert
            ReverseConsoleOutput(stringWriter, consoleOutput);

            Assert.Equal("Hello in Program!\r\n", stringWriter.ToString());
        }

        private static void ReverseConsoleOutput(StringWriter stringWriter, TextWriter consoleOutput)
        {
            Console.SetOut(consoleOutput);
            stringWriter.Dispose();
        }

        private static void SwitchConsoleOutput(out StringWriter stringWriter, out TextWriter consoleOutput)
        {
            stringWriter = new StringWriter();
            consoleOutput = Console.Out;
            Console.SetOut(stringWriter);
        }
    }
}
