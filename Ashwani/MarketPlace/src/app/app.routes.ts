import { Routes } from '@angular/router';
import { ProductComponent } from './component/product/product.component';
import { OperatersComponent } from './component/operaters/operaters.component';

export const routes: Routes = [
    { 
        path: 'product/:id', 
        component: ProductComponent ,
    },
    { 
        path: 'operator', 
        component: OperatersComponent ,
        children:[
            {
                path: 'product/:id', 
                component: ProductComponent
            }
        ]
    },
    { path: '', redirectTo: '', pathMatch: 'full' }, 
    { path: '**', component:OperatersComponent }

];
