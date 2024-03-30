package condition

import "testing"

func TestIfMultiSec(t *testing.T) {
	if a := 1 == 1; a {
		t.Log("1==1")
	}

	//if v, err := someFun(); err == nil {
	//	t.Log("1==1")
	//} else {
	//	t.Log("1==1")
	//}
}
