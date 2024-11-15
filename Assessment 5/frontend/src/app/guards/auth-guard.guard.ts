import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { inject } from '@angular/core';

export const authGuardGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const router = inject(Router);
  
  const isSessionActive = localStorage.getItem("session") === "true";
  const protectedRoutes = ["/patient", "/change-password"];
  
  if (protectedRoutes.includes(state.url) && isSessionActive) {
    return true;
  } else {
    router.navigate(["/"]);
    return false;
  }
};