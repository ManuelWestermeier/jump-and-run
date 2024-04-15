using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
	public float Horizontal = 0;
	public float Vertical = 0;
	public float Slide = 0;
	
	public void PointerDownForward() 
	{
		Horizontal = 1;
	}	
	public void PointerUpForward() 
	{
		Horizontal = 0;
	}
	
	
	public void PointerDownBackwards() 
	{
		Horizontal = -1;
	}	
	public void PointerUpBackwards() 
	{
		Horizontal = 0;
	}
	
	

	public void PointerDownUpwards() 
	{
		Vertical = 1;
	}
	
	public void PointerUpUpwards() 
	{
		Vertical = 0;
	}
	
	
	public void PointerDownDownwards() 
	{
		Vertical = -1;
	}	
	public void PointerUpDownwards() 
	{
		Vertical = 0;
	}

	public void PointerDownSlide()
	{
		Slide = 1;
	}	
	public void  PointerUpSlide()
	{
		Slide = 0;
	}
}
