using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Models
{
    public class ErrorListModel
    {
        public string EntityName { get; set; }
        public List<ErrorModel> Errors { get; set; }
    }
}
