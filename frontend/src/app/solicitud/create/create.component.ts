import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

import {  FormGroup, FormControl, Validators } from '@angular/forms';


import { SolicitudService } from '../solicitud.service';

import { MatFormField } from '@angular/material/form-field';
import { MatSelect, MatOption } from '@angular/material/select';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [ 
    RouterModule,
    CommonModule,
    MatFormField,
    MatSelect,
    MatOption
  ],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {

  
  form!: FormGroup;


  constructor(private solicitudService: SolicitudService, private router: Router) {}

  ngOnInit() {
    // Logic to fetch and display the solicitud details can be added here
    this.form = new FormGroup({
      titulo: new FormControl<string | null>(null, [Validators.required]),
      descripcion: new FormControl<string | null>(null, [Validators.required]),
      estado: new FormControl<string | null>(null, [Validators.required]),
      prioridad: new FormControl<string | null>(null, [Validators.required]),
    });
  }

  get f() {
    return this.form.controls;
  }

  submit() {
    console.log(this.form.value);
    this.solicitudService.createSolicitud(this.form.value).subscribe((res: any) => {
      console.log('Solicitud fetched successfully:', res);
      this.router.navigate(['/solicitud/index']);
    });
  }
}
