import { inject } from '@angular/core';
import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

export const authGuardGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const router = inject(Router);
  
  const isSessionActive = localStorage.getItem("session") === "true";
  const protectedRoutes = ["/home", "/profile", "/cart", "/orders", "/appointment"
    , "/appointment-history", "/patient-profile" ,"/provider-profile"];
  
  if ((protectedRoutes.includes(state.url) || state.url.startsWith("/complete-appointment/") || state.url.startsWith("/provider-chat/") || state.url.startsWith("/patient-chat/") ) && isSessionActive) {
    return true;
  } else {
    router.navigate(["/"]);
    return false;
  }
};