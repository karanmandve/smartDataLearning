import { Routes } from '@angular/router';
import { StructuralDirectiveComponent } from './components/structural-directive/structural-directive.component';
import { AttributeDirectiveComponent } from './components/attribute-directive/attribute-directive.component';

export const routes: Routes = [
    {path: "", component : StructuralDirectiveComponent},
    {path: "attribute-directive", component: AttributeDirectiveComponent}
];
