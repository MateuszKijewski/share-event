import React, { Component } from 'react'
import Header from './components/Header'
import CreateEvent from './components/CreateEvent'
import { Provider, connect } from 'react-redux';
import Store from './redux/store'
import ModalContainer from './components/ModalContainer'


export class App extends Component {
  render() {
    return (
      <Provider store={Store}>
        <div className="App">
          <Header />
          <ModalContainer />
        </div>
      </Provider>
    )
  }
}


export default App