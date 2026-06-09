import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardHomeComponent } from './pages/dashboard-home/dashboard-home.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HeaderComponent } from './components/header/header.component';
import { TrafficFinesComponent } from './pages/traffic-fines/traffic-fines.component';
import { DrivingLicenseComponent } from './pages/driving-license/driving-license.component';
import { PaymentFinesComponent } from './pages/payment-fines/payment-fines.component';

@NgModule({

  declarations: [
    DashboardHomeComponent,
    SidebarComponent,
    HeaderComponent,
    TrafficFinesComponent,
    DrivingLicenseComponent,
    PaymentFinesComponent
  ],

  imports: [
    CommonModule,
    DashboardRoutingModule
  ]

})

export class DashboardModule { }