import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { FogotpasswordComponent } from './fogotpassword/fogotpassword.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'fogotpassword', component: FogotpasswordComponent},
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule {}