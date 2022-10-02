export const editEmployeeData = (payload) => {
  return {
    type: "EDIT_EMPLOYEE_DATA",
    payload: payload,
  };
};
export const editAdminData = (payload) => {
  return {
    type: "EDIT_ADMIN_DATA",
    payload: payload,
  };
};
export const loggedUserData = (payload) => {
  console.log(payload);
  return {
    type: "LOGGED_USER_DATA",
    payload: payload,
  };
};
export const changeStatusOfEmployeeForm = (payload) => {
  console.log(payload);
  return {
    type: "CHANGE_STATUS_OF_EMPLOYEE_FORM",
    payload: payload,
  };
};
