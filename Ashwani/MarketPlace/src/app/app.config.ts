import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import {provideEffects} from '@ngrx/effects'
import {provideStore} from '@ngrx/store'
import {provideStoreDevtools} from '@ngrx/store-devtools'
import { groceryReduser } from './store/redux/grocery.redux';
import { bucketreducer } from './store/redux/bucket.redux';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), provideClientHydration(),
    provideStore({
     groceries:groceryReduser,
      bucketItems:bucketreducer
    }),
    provideEffects(),
    provideStoreDevtools()
  ]
};
