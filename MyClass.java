import java.util.*;
public class MyClass extends Thread{
	Elements obj;
    class Elements{
    	String location;
    	boolean SetOrNot;
    	Calendar cal;
    	void getDate() {
    		//we will get date and time from the user as Date object and initialize 'cal'
    	}
    	void getSetOrNot() {
    		//get whether the trigger is set or unset;
    	}
    	void getLocation() {
    		//get the location as string so gMaps may be used to get postion.
    	}
    }
    public MyClass() {
    	this.obj=new Elements();
    	obj.getDate();obj.getSetOrNot();obj.getLocation();
    	if(obj.SetOrNot) this.startBooking();
    }
    void startBooking(){
		this.start();
	}
    void toggle(){
    	//it is invoked when user will toggle the switch
    	this.obj.SetOrNot=!this.obj.SetOrNot;
    	if(obj.SetOrNot) this.startBooking();
    }
    void BookTheRide(){
    	//API call for start searching for ride and giving prompt if ride is found
		//A notification should be sent to tell about the fare.
	}
    public void run(){
        try {
        	Calendar temp=Calendar.getInstance();
        	this.obj.cal.add(Calendar.MINUTE,-15);
			while(!temp.after(this.obj.cal)) Thread.sleep(1000);
			this.BookTheRide();
        }
        catch (Exception e) {
            System.out.println("Exception occurred");
        }
    }
}
