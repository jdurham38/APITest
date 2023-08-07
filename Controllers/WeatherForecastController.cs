using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPut("{id}")]
        public IActionResult UpdateReminder(int id, [FromBody] ReminderModel updatedReminder)
        {
            var existingReminder = reminders.FirstOrDefault(r => r.Id == id);
            if (existingReminder == null)
            {
                return NotFound("Reminder not found.");
            }

            // Update the fields of the existing reminder with the new values
            existingReminder.DateTime = updatedReminder.DateTime;
            existingReminder.Description = updatedReminder.Description;
            existingReminder.Priority = updatedReminder.Priority;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReminder(int id)
        {
            var reminderToDelete = reminders.FirstOrDefault(r => r.Id == id);
            if (reminderToDelete == null)
            {
                return NotFound("Reminder not found.");
            }

            reminders.Remove(reminderToDelete);

            return NoContent();
        }
    }
}
