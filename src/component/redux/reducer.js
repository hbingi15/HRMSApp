const initialState = {
  employeeData: {},
  edit: false,
  adminData: {},
  userData: {},
  count:0,
};

export const employeeReducer = (state = initialState, action) => {
  const { type, payload } = action;
  switch (type) {
    case "EDIT_EMPLOYEE_DATA": {
      let { data ,count} = payload;
      return {
        ...state,
        employeeData: {
          ...state.employeeData,
          data,
        },
        edit: true,
        count:count
      };
    }
    case "CHANGE_STATUS_OF_EMPLOYEE_FORM": {
      
      return {
        ...state,
        
        edit: payload?.status,
      };
    }

    default:
      return state;
  }
};
