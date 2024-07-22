import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../enviroments/enviroment'; // Imports environment configuration.

export interface TodoItem {
  id: number; // Unique identifier for the TODO item.
  title: string; // Title or description of the TODO item.
}

@Injectable({
  providedIn: 'root' // Registers the service with Angular's dependency injection system.
})
export class TodoService {
  private apiUrl = `${environment.apiUrl}/todo`; // API URL for accessing TODO items.

  constructor(private http: HttpClient) { } // Injects HttpClient to make HTTP requests.

  getTodos(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.apiUrl); // Sends a GET request to fetch all TODO items.
  }

  addTodo(todo: TodoItem): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.apiUrl, todo); // Sends a POST request to add a new TODO item.
  }

  deleteTodo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`); // Sends a DELETE request to remove a TODO item by ID.
  }
}
