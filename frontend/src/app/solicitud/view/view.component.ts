import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Router, ActivatedRoute } from '@angular/router';

import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';

import { SolicitudService } from '../solicitud.service';

import { Solicitud } from '../solicitud';

@Component({
  selector: 'app-view',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {
  id!: number;
  solicitud!: Solicitud;

  constructor(
    private solicitudService: SolicitudService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.solicitudService.getSolicitud(this.id).subscribe((data: Solicitud) => {
      this.solicitud = data;
      console.log('Solicitud fetched successfully:', this.solicitud);
    });
  }
}
