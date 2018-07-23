import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs'
import { catchError, map, tap } from 'rxjs/operators';
import {TnkLfeRequest} from './TnkLfeRequest';
import { MessageService } from './message.service';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class TnklfeRequestService {
  constructor(private http:HttpClient,private messageService:MessageService ) { }

  apiUrl: string = "http://localhost:50661/api/request";

  GetRequest(id: number): Observable<TnkLfeRequest> {
    const url = this.apiUrl+'/'+id;
    return this.http.get<TnkLfeRequest>(url).pipe(
      tap(_ => this.log('fetched request id=${id}')),
      catchError(this.handleError<TnkLfeRequest>('GetRequest id=${id}'))
    );
  }


  GetAllRequests(): Observable<TnkLfeRequest[]> 
  {
    const url = this.apiUrl;
    return this.http.get<TnkLfeRequest[]>(url)
    .pipe(
      tap(requests => this.log('get all request')),
      catchError(this.handleError('GetAllRequests', []))
    );
  }
 
 UpdateRequest(request:TnkLfeRequest): Observable<any>
 {
   const url = this.apiUrl+"/UpdateRequest";
   console.log(request.Description);
   console.log(request.Summary);
   
   return this.http.put(url,request,httpOptions)
   .pipe(
      tap(_=> this.log(`updated request id=${request.Id}`)),
      catchError(this.handleError<any>('UpdateRequest'))
   );
 }
 

  
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      console.log('inside error');
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

    /** Log a HeroService message with the MessageService */
    private log(message: string) {
      console.log(message);
      this.messageService.add(`HeroService: ${message}`);
    }
}
