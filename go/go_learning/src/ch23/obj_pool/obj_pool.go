package obj_pool

import (
	"errors"
	"time"
)

type ReusableObj struct {
}

type ObjPool struct {
	bufchan chan *ReusableObj // 用于缓冲可重用对象
}

func NewObjPool(numOfObj int) *ObjPool {
	ObjPool := ObjPool{}
	ObjPool.bufchan = make(chan *ReusableObj, numOfObj)
	for i := 0; i < numOfObj; i++ {
		ObjPool.bufchan <- &ReusableObj{}
	}
	return &ObjPool
}

func (p *ObjPool) GetObj(timeout time.Duration) (*ReusableObj, error) {
	select {
	case ret := <-p.bufchan:
		return ret, nil
	case <-time.After(timeout):
		return nil, errors.New("time out")
	}
}

func (p *ObjPool) ReleaseObj(obj *ReusableObj) error {
	select {
	case p.bufchan <- obj:
		return nil
	default:
		return errors.New("overflow")

	}
}
