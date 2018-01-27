#include "Config.h"

#include "SPI_ISP.h"
#include "Com.h"

void setup() 
{
	isp_init();
	
	com_init();
}

void loop() 
{
	com_loop();
}
