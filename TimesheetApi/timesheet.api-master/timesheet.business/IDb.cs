using System;
using System.Collections.Generic;
using System.Text;
using timesheet.data;

namespace timesheet.business
{
    public interface IDb
    {
        TimesheetDb db { get; }
    }
}
