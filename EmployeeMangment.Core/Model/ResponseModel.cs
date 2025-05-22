using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Core.Model
{
    public class ResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; } = "Success";
        public object? Data { get; set; }
    }
}
