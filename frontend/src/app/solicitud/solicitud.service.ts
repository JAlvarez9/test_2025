import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Solicitud, SolicitudCreate } from './solicitud';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {

  constructor(private httpClient: HttpClient) { }

  private apiUrl = 'http://localhost:5000/api/Solicitud/';
  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
  });

  getSolicitudes(): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}GetAll`, { headers: this.headers });
  }

  getSolicitud(id: number): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}GetById/${id}`, { headers: this.headers });
  }

  createSolicitud(solicitud: SolicitudCreate): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}Create`, solicitud, { headers: this.headers });
  }

  updateSolicitud(solicitud: Solicitud): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}Update`, solicitud, { headers: this.headers });
  }

  deleteSolicitud(id: number): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}Delete/${id}`, { headers: this.headers });
  }

  UpdateEstado(id: number, estado: string): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}UpdateEstado/${id}/${estado}`, { headers: this.headers });
  }

  UpdatePrioridad(id: number, prioridad: string): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}UpdatePrioridad/${id}/${prioridad}`, { headers: this.headers });
  }
}
