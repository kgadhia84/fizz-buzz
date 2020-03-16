using System.Collections.Generic;

namespace FizzBuzz.Services.Models
{
    public class ReportModel
    {
        public ReportModel(List<string> output, Dictionary<string, int> reportOutput)
        {
            Output = output;
            ReportOutput = reportOutput;
        }

        public List<string> Output { get; }

        public Dictionary<string, int> ReportOutput { get; }
    }
}
