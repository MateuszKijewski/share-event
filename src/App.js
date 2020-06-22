import React, { Component } from 'react'
import Header from './components/Header'
import { Provider } from 'react-redux';
import Store from './redux/store'
import {
  BrowserRouter as Router,
  Route,
  useParams
} from "react-router-dom";
import ModalContainer from './components/ModalContainer'


export class App extends Component {
  render() {
    let Child = () => {
      let {id} = useParams()

      return(
        <Header id={id}/>
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