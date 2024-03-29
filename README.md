# Note

프로젝트 개요:
Enterprise Architecture를 기반 프로젝트를 구성하였다. (본 프로젝트에서는 생성자, 인터페이스를 통한 주입 사용)</br>
비즈니스 로직을 담당하는 BusinessLogicLayer (BLL), 공통 모델을 구성하는 Common, 데이터 접근을 담당하는 DataAccessLayer (DAL), 웹 프레젠테이션을 담당하는 PresentationLayer를 생성했다. (솔루션 폴더)</br>
각 폴더에 클래스 라이브러리를 생성하였으며, 코드의 재사용성을 높이고 다른 데이터베이스를 사용할 수 있도록 확장성을 갖추고 있다. </br>
실행 시 클라이언트 버튼을 통해 ASP.NET MVC 리스트 출력 호출이 시작되며, 순차적으로 BLL, IDAL, 그리고 DAL이 호출되어 데이터를 처리한다.</br>

폴더 및 클래스 라이브러리 구성:

- BusinessLogicLayer (BLL): 비즈니스 로직을 담당하는 계층으로, 기업의 비즈니스 규칙과 로직을 구현한다. 이 계층은 DataAccessLayer과 PresentationLayer 사이에서 중간 역할을 수행한다.

- Common: 공통적으로 사용되는 모델과 유틸리티 클래스 등을 구성하는 공통 모듈이다. 이를 통해 코드의 중복을 방지하고 일관성 있는 기능을 제공한다.

- DataAccessLayer (DAL): 데이터베이스와의 상호 작용을 담당하는 계층으로, 데이터 접근을 추상화하여 데이터베이스 독립성을 확보한다. </br>
다른 데이터베이스를 사용할 경우, 해당 데이터베이스에 맞는 클래스 라이브러리를 추가하고 DI 컨테이너에 등록하여 변경에 유연하게 대처할 수 있다.
</br>
Db와 직접 통신하는 DAL과 인터페이스 모음인 IDAL을 분리하여 만들었다. </br>
이렇게 분리함으로써, 데이터베이스와의 통신에 대한 구체적인 구현을 DAL에서 처리하고, </br>
데이터 접근 계층을 추상화한 IDAL을 통해 느슨한 결합을 유지한다. </br>

- DAL: 데이터베이스와 직접 통신하고 데이터 조작 작업을 수행하는 클래스들로 구성된다.</br>
각 클래스는 특정 데이터베이스 (예: SQL Server, MySQL, Oracle 등)와 상호작용하며, </br>
해당 데이터베이스에 특화된 쿼리 및 데이터 조작 기능을 담당한다.</br>

- IDAL: DAL에서 구현된 클래스들에 대한 인터페이스를 정의한다. </br>
각 인터페이스는 특정 데이터 접근 기능에 대한 메서드들을 추상화하여 선언한다.</br>

의존성 주입 설정 (Program.cs): 의존성 주입 설정에서 IDAL과 해당 데이터베이스에 맞는 DAL 클래스를 연결</br>


- PresentationLayer: 웹 프레젠테이션 계층으로, 사용자와 상호작용하며 UI를 통해 데이터를 보여주고 입력받는다. </br>
클라이언트의 요청을 받아 ASP.NET MVC 리스트 출력을 호출하고, 이후 비즈니스 로직 계층인 BLL로 전달한다.</br>

의존성 주입 설정 (Program.cs):
의존성 주입은 DI 컨테이너를 활용하여 각 계층 간의 의존성을 관리하는 설정이다. Program.cs 파일에서 다음과 같이 서비스를 컨테이너에 등록한다</br>

//BusinessLogicLayer (BLL) 서비스 등록</br>
builder.Services.AddTransient<UserBll>();</br>
</br>
//IUserDal, UserDal 서비스 등록</br>
builder.Services.AddTransient<IUserDal, UserDal>();</br>
</br>
위 설정은 UserBll 클래스와 UserDal 클래스가 의존성 주입을 받을 수 있도록 등록한다. </br>
이를 통해 비즈니스 로직 계층에서 데이터 접근 계층에 의존성을 주입할 수 있으며, 인터페이스를 사용함으로써 느슨한 결합을 유지한다.</br>
</br>
결론:</br>
이러한 구성을 통해 Enterprise Architecture 기반의 프로젝트는 유연성과 확장성을 갖추면서, 코드의 재사용성을 높이고 중복을 최소화하여 유지보수성을 강화할 수 있다. </br>
의존성 주입을 통해 계층 간의 강한 결합을 피하고, 인터페이스를 사용하여 계층 간의 상호작용을 추상화하여 개발자들이 보다 효율적으로 협업할 수 있다.</br>

참고:
개발토끼
https://www.youtube.com/watch?v=dKvCZUec100&list=PLbPz1r_wDPhEcKDJbOBw_3h5c2gtyDicX&index=27
