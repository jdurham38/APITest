using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Reminder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : ControllerBase
    {
        private static List<ReminderModel> reminders = new List<ReminderModel>();

        [HttpGet]
        public IActionResult GetReminders()
        {
            return Ok(reminders);
        }

        [HttpPost]
        public IActionResult CreateReminder([FromBody] ReminderModel reminder)
        {
            if (reminder == null)
            {
                return BadRequest("Invalid reminder data.");
            }

            reminder.Id = reminders.Count + 1;
            reminders.Add(reminder);

            return CreatedAtAction(nameof(GetReminders), null);
        }
    }
}
