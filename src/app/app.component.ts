import { Component, OnInit } from '@angular/core';
import { TodoService, TodoItem } from './todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  todos: TodoItem[] = [];
  newTodoTitle = '';

  constructor(private todoService: TodoService) {}

  ngOnInit() {
    this.loadTodos();
  }

  loadTodos() {
    this.todoService.getTodos().subscribe(todos => this.todos = todos);
  }

  addTodo() {
    if (this.newTodoTitle.trim()) {
      this.todoService.addTodo({ title: this.newTodoTitle } as TodoItem).subscribe(() => {
        this.newTodoTitle = '';
        this.loadTodos();
      });
    }
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.loadTodos();
    });
  }
}