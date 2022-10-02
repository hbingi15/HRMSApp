import { applyMiddleware, combineReducers, createStore } from "redux";
import thunk from "redux-thunk";
import { loggedInReducer } from "./loggedUserDataReducer";
import { employeeReducer } from "./reducer";

const rootReducer = combineReducers({
  employeeData: employeeReducer,
  loggedInData: loggedInReducer,
});
let store = createStore(
  rootReducer,
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
  //   applyMiddleware(thunk)
);

export { store };
