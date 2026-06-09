import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardHomeComponent } from './pages/dashboard-home/dashboard-home.component';
import { TrafficFinesComponent } from './pages/traffic-fines/traffic-fines.component';
import { DrivingLicenseComponent } from './pages/driving-license/driving-license.component';
import { PaymentFinesComponent } from './pages/payment-fines/payment-fines.component';

const routes: Routes = [

  { path: 'dashboard-home', component: DashboardHomeComponent },
  { path: 'traffic-fines', component: TrafficFinesComponent },
  { path: 'driving-license', component: DrivingLicenseComponent },
  { path: 'payment-fines', component: PaymentFinesComponent}
];

@NgModule({

  imports: [
    RouterModule.forChild(routes)
  ],

  exports: [
    RouterModule
  ]

})

export class DashboardRoutingModule { }