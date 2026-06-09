import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputComponent } from './components/input/input.component';
import { ButtonComponent } from './components/button/button.component';
import { CheckboxComponent } from './components/checkbox/checkbox.component';



@NgModule({
  declarations: [
    InputComponent,
    ButtonComponent,
    CheckboxComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
