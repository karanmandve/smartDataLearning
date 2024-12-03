import { HttpHandler, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { LoaderService } from '../services/loader/loader.service';
import { inject } from '@angular/core';
import { finalize, Observable } from 'rxjs';

export const customInterceptor: HttpInterceptorFn = (req, next) => {

 const loaderService = inject(LoaderService);

 loaderService.show();

 const token = sessionStorage.getItem('token');
 const authReq = token
   ? req.clone({
       setHeaders: {
         Authorization: `Bearer ${token}`,
       },
     })
   : req;
   
 return next(authReq).pipe(
   finalize(() => loaderService.hide())
 );
};
