const initialState = {
    holidayData: {},
    edit: false,
   
    count:0,
  };
  
  export const holidayReducer = (state = initialState, action) => {
    const { type, payload } = action;
    switch (type) {
      case "EDIT_HOLIDAY_DATA": {
        let { data ,count} = payload;
        return {
          ...state,
          holidayData: {
            ...state.holidayData,
            data,
          },
          edit: true,
          count:count
        };
      }
      case "CHANGE_STATUS_OF_HOLIDAY_FORM": {
        
        return {
          ...state,
          
          edit: payload?.status,
        };
      }
  
      default:
        return state;
    }
  };
  