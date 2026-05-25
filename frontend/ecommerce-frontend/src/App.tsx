import { useEffect } from 'react'
import keycloak from './libs/keycloak'



let keycloakinit = false;
function App() {

   

  
 useEffect(() => {
   
  if(keycloakinit) {
     return;
  }




    keycloak.init({ onLoad: 'login-required' }).then((authenticated) => {
      if (authenticated) {
        console.log('Authenticated');
        console.log('Token:', keycloak.token);
      } else {
        console.log('Not authenticated');
      }}).catch((error) => {
        console.error('Failed to initialize Keycloak:', error);
      });

      keycloakinit = true;

  }, []);



  return (
    <>
      
      
    </>
  )
}

export default App
