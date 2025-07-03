import { Routes } from '@angular/router';

import { IndexComponent } from './solicitud/index/index.component';
import { CreateComponent } from './solicitud/create/create.component';
import { ViewComponent } from './solicitud/view/view.component';
import { UpdateAComponent } from './solicitud/update-a/update-a.component';
import { UpdateEComponent } from './solicitud/update-e/update-e.component';
import { UpdatePComponent } from './solicitud/update-p/update-p.component'; 


export const routes: Routes = [
    {path: 'solicitud', redirectTo: 'solicitud/index', pathMatch: 'full'},
    {path: 'solicitud/index', component: IndexComponent},
    {path: 'solicitud/create', component: CreateComponent},
    {path: 'solicitud/view/:id', component: ViewComponent},
    {path: 'solicitud/update-e/:id', component: UpdateEComponent},
];
