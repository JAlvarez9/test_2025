import { Component } from '@angular/core';

import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SolicitudService } from '../solicitud.service';

@Component({
  selector: 'app-update-e',
  standalone: true,
  imports: [
    RouterModule,
    CommonModule
  ],
  templateUrl: './update-e.component.html',
  styleUrl: './update-e.component.css'
})
export class UpdateEComponent {

constructor(private solicitudService: SolicitudService) { }

  estado: string = '';
  id: number = 0;

  ngOnInit() {
    // Aquí puedes agregar la lógica para inicializar el componente
    
    console.log('UpdateEComponent initialized');
  }

  // Aquí puedes agregar métodos para manejar la actualización de estado
  updateEstado(id: number, estado: string) {
    this.solicitudService.UpdateEstado(id, estado).subscribe(
      response => {
        console.log('Estado actualizado:', response);
      },
      error => {
        console.error('Error al actualizar el estado:', error);
      }
    );
  }

}
