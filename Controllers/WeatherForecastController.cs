using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Reminder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : ControllerBase
    {
        private static List<string> reminders = new List<string>();

        [HttpGet]
        public IActionResult GetReminders()
        {
            return Ok(reminders);
        }

        [HttpPost]
        public IActionResult AddReminder([FromBody] string reminder)
        {
            if (!string.IsNullOrWhiteSpace(reminder))
            {
                reminders.Add(reminder);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid reminder");
            }
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteReminder(int index)
        {
            if (index >= 0 && index < reminders.Count)
            {
                reminders.RemoveAt(index);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
