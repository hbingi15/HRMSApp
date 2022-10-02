const initialState = {
  LoggedUserData: {},
};

export const loggedInReducer = (state = initialState, action) => {
  const { type, payload } = action;
  switch (type) {
    case "LOGGED_USER_DATA": {
      //   let { data } = payload;
      console.log(payload);
      return {
        ...state,
        LoggedUserData: {
          ...state.LoggedUserData,
          LoggedUserData: payload?.data?.userData,
        },
      };
    }
    // console.log(state.userData);

    default:
      return state;
  }
};
