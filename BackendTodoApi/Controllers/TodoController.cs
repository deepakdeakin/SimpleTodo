using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// Defines the TodoController class, handling HTTP requests for TODO items.
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    // In-memory storage for TODO items.
    private static List<TodoItem> _todos = new List<TodoItem>();
    private static int _idCounter = 1; // Counter for generating unique IDs for TODO items.

    // GET api/todo - Retrieves all TODO items.
    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetAll()
    {
        return Ok(_todos); // Returns the list of TODO items with a 200 OK status.
    }

    // POST api/todo - Adds a new TODO item.
    [HttpPost]
    public ActionResult<TodoItem> Add(TodoItem todo)
    {
        todo.Id = _idCounter++; // Assigns a unique ID to the new TODO item.
        _todos.Add(todo); // Adds the new TODO item to the list.
        return CreatedAtAction(nameof(GetAll), new { id = todo.Id }, todo); // Returns a 201 Created status with the location of the new TODO item.
    }

    // DELETE api/todo/{id} - Deletes a TODO item by ID.
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var todo = _todos.Find(t => t.Id == id); // Finds the TODO item with the specified ID.
        if (todo == null)
        {
            return NotFound(); // Returns a 404 Not Found status if the TODO item is not found.
        }

        _todos.Remove(todo); // Removes the TODO item from the list.
        return NoContent(); // Returns a 204 No Content status indicating successful deletion.
    }
}
