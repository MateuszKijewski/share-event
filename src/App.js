import React, { Component } from 'react'
import Header from './components/Header'
import ReservationHeader from './components/Reservation/ReservationHeader'
import { Provider } from 'react-redux';
import Store from './redux/store'
import {
  BrowserRouter as Router,
  Route,
  useParams
} from "react-router-dom";
import ModalContainer from './components/ModalContainer'
import ReservationModalContainer from './components/Reservation/ReservationModalContainer';


export class App extends Component {
  render() {
    let Child = () => {
      let {id} = useParams()

      return(
        <React.StrictMode>
          <ReservationHeader id={id}/>
          <ReservationModalContainer />
        </React.StrictMode>
      )
    }    
    return (
      <Provider store={Store}>
            <div className="App">
              <Router>
                <Route exact path="/">
                  <Header />
                  <ModalContainer />
                </Route>
                <Route exact path="/:id" children={<Child />}>
                </Route>
              </Router>
            </div>
      </Provider>
    )
  }
}


export default App