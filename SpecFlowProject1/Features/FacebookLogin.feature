# language: es
Característica: Inicio de sesion
	Como usuario registrado en Facebook
	Quiero iniciar sesion
	Para visualizar mi perfil de usuario

@smoke
Esquema del escenario: Inicio de sesión Facebook
	Dado que ingreso al sitio web de Facebook
	Y pongo los siguientes detalles
		| username  | password     |
		| userEmail | userPassword |  	
	Y le doy click en el botón Entrar
	Entonces podré ver mi nombre de perfil


