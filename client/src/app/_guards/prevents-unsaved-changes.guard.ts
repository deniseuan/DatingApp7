import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { inject } from '@angular/core';
import { ConfirmServiceService } from '../_services/confirm-service.service';

export const preventsUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component) => {
  const confirmService = inject(ConfirmServiceService);
  if (component.editForm?.dirty) {
    return confirmService.confirm();
  }
  return true;
};
