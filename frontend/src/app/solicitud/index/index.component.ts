import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SolicitudService } from '../solicitud.service';

import { Solicitud } from '../solicitud';

import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css',
})
export class IndexComponent {
  solicitudes: Solicitud[] = [];

  displayedColumns: string[] = [
    'id',
    'titulo',
    'estado',
    'prioridad',
    'view',
    'update',
    'updateEstado',
    'updatePrioridad',
    'delete',
  ];

  constructor(private solicitudService: SolicitudService) {}

  ngOnInit() {
    this.solicitudService.getSolicitudes().subscribe((data: Solicitud[]) => {
      this.solicitudes = data;
      console.log('Solicitudes fetched successfully:', this.solicitudes);
    });
  }

  deleteSolicitud(id: number) {
    this.solicitudService.deleteSolicitud(id).subscribe(
      () => {
        console.log(`Solicitud with id ${id} deleted successfully`);
        this.solicitudes = this.solicitudes.filter((s) => s.id !== id);
      },
      (error) => {
        console.error('Error deleting solicitud:', error);
      }
    );
  }

  updateEstado(id: number, estado: string) {
    this.solicitudService.UpdateEstado(id, estado).subscribe(
      () => {
        console.log(`Estado of solicitud with id ${id} updated to ${estado}`);
        const solicitud = this.solicitudes.find((s) => s.id === id);
        if (solicitud) {
          solicitud.estado = estado ?? 'Pendiente'; // Default to 'Pendiente' if estado is null or undefined
        }
      },
      (error) => {
        console.error('Error updating estado:', error);
      }
    );
  }

  updatePrioridad(id: number, prioridad: string) {
    this.solicitudService.UpdatePrioridad(id, prioridad).subscribe(
      () => {
        console.log(
          `Prioridad of solicitud with id ${id} updated to ${prioridad}`
        );
        const solicitud = this.solicitudes.find((s) => s.id === id);
        if (solicitud) {
          solicitud.prioridad = prioridad ?? 'Baja'; // Default to 'Baja' if prioridad is null or undefined
        }
      },
      (error) => {
        console.error('Error updating prioridad:', error);
      }
    );
  }
}
